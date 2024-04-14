import { Component, Inject, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TempoTimerConfig } from '../../models/tempo-timer-config.model';
import { Router } from '@angular/router';
import { StartButtonComponent } from '../start-button/start-button.component';
import { interval, map, Observable, takeWhile, tap } from 'rxjs';
import { TempoContractGuideComponent } from '../tempo-contract-guide/tempo-contract-guide.component';
import { RestGuideComponent } from '../rest-guide/rest-guide.component';
import { TimerService } from '../../services/timer.service';

@Component({
  selector: 'kt-tempo-timer',
  standalone: true,
  imports: [
    CommonModule,
    StartButtonComponent,
    TempoContractGuideComponent,
    RestGuideComponent,
  ],
  templateUrl: './tempo-timer.component.html',
  styleUrls: ['./tempo-timer.component.scss']
})
export class TempoTimerComponent {
  // enum
  readonly Phase = Phase;

  readonly config!: TempoTimerConfig;

  isStarted = false;
  currentSet = 1;
  currentRep = 1;
  totalTimer$!: Observable<number>;
  readonly time$: Observable<number>;
  phaseTimer!: number;
  phase!: Phase;
  panelOpenState = false;
  private isDone = false;

  private readonly advancePhase!: Function;

  constructor(
    private router: Router,
    private timer: TimerService
  ) {
    this.time$ = timer.time$;
    const routerState= this.router.getCurrentNavigation()?.extras.state;
    if (routerState) {
      this.config = routerState as TempoTimerConfig;
      this.phase = this.config.isPushExercise ? Phase.Eccentric : Phase.Concentric;
      this.phaseTimer = this.config.isPushExercise ? this.config.eccentricTime : this.config.concentricTime;
      this.advancePhase = this.createPhaseAdvanceFn(this.config.isPushExercise);
    } else {
      // redirect to error page/flash error message and redirect to home page
      console.error('navigated incorrectly')
    }
  }

  onStarterFinished() {
    this.isStarted = true;
    this.timer.start();
    this.totalTimer$ = interval(1000)
      .pipe(
        map(time => ++time),
        tap(time => this.onTick(time)),
        takeWhile(() => !this.isDone),
      );
  }

  done() {
    this.isDone = true;
  }

  pausePlay() {
    // TODO pause the timer/continue a paused timer
    console.log('not implemented yet.')
  }

  private onTick(time: number) {
    this.tickPhaseTimer();
  }

  private incrementRep() {
    if (this.currentRep === this.config.repsPerSet) {
      this.incrementSet();
      this.setRest();
    } else {
      this.currentRep++;
    }
  }

  private incrementSet() {
    if (this.currentSet === this.config.sets) {
      this.done();
    } else {
      this.currentSet++;
      this.currentRep = 1;
    }
  }

  private tickPhaseTimer() {
    if (this.phaseTimer === 1) {
      this.advancePhase();
      return;
    }
    this.phaseTimer--;
  }

  /**
   * Creates the function used to advance to the next phase at
   * the end of a phase countdown. This function's behaviour is
   * different for push/pull exercises reflecting the order in
   * which eccentric/concentric muscle contractions occur for
   * differing exercising directions.
   * Side effects increment repetition count and set exercise
   * phase to the next one, resetting the phase countdown per
   * phase and configuration.
   * @param isPush
   */
  private createPhaseAdvanceFn = (isPush: boolean) => {
    const nextPushPhase = () => {
      switch (this.phase) {
        case Phase.Concentric:
          this.setEccentric();
          this.incrementRep();
          return;
        case Phase.Eccentric:
          this.setConcentric();
          return;
        case Phase.Rest:
          this.setConcentric();
          return;
      }
    }
    const nextPullPhase = () => {
      switch (this.phase) {
        case Phase.Concentric:
          this.setEccentric();
          return;
        case Phase.Eccentric:
          this.setConcentric();
          this.incrementRep();
          return;
        case Phase.Rest:
          this.setConcentric();
          return;
      }
    }
    return isPush ? nextPushPhase : nextPullPhase;
  }

  private setRest() {
    this.phase = Phase.Rest;
    this.phaseTimer = this.config.restTime;
  }
  private setConcentric() {
    this.phase = Phase.Concentric;
    this.phaseTimer = this.config.concentricTime;
  }
  private setEccentric() {
    this.phase = Phase.Eccentric;
    this.phaseTimer = this.config.eccentricTime;
  }
}

enum Phase {
  Eccentric = 0,
  Concentric = 1,
  Rest = 2,
}
