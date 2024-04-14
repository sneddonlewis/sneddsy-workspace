import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TempoTimerConfig } from '../../models/timer-config';
import { Router } from '@angular/router';
import { routePaths } from '../../app.routes';

@Component({
  selector: 'kt-tempo-timer-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './tempo-timer-list.component.html',
  styleUrls: ['./tempo-timer-list.component.scss']
})
export class TempoTimerListComponent {
  timerConfigs: TempoTimerConfig[] = [
    new class implements TempoTimerConfig {
      concentricTime = 2;
      eccentricTime = 4;
      isPushExercise = true;
      name = 'GVT Compound Push';
      repsPerSet = 10;
      sets = 10;
      restTime = 90;
    },
    new class implements TempoTimerConfig {
      concentricTime = 2;
      eccentricTime = 4;
      isPushExercise = false;
      name = 'GVT Compound Pull';
      repsPerSet = 10;
      sets = 10;
      restTime = 90;
    },
  ];

  constructor(private router: Router) {
  }

  onSelectTimer(config: TempoTimerConfig) {
    console.log(config);
    this.router.navigate([routePaths.tempoTimer], {state: config}).then();
  }
}
