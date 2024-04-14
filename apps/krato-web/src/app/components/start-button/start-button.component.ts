import { Component, EventEmitter, OnDestroy, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { interval, map, Subscription, take, tap } from 'rxjs';

@Component({
  selector: 'kt-start-button',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './start-button.component.html',
  styleUrls: ['./start-button.component.scss']
})
export class StartButtonComponent implements OnDestroy {
  @Output() starterFinished = new EventEmitter<void>();

  private subs: Subscription[] = []
  private countDown = 3;
  private countDown$ = interval(1000)
    .pipe(
      take(this.countDown),
      map(value => this.countDown - value),
    )
  countDownDisplay = 'Go'

  constructor() {
  }

  ngOnDestroy(): void {
    this.subs.map(s => s.unsubscribe())
  }

  startCountdown() {
    this.countDownDisplay = this.countDown.toString()
    const sub = this.countDown$
      .pipe(
        tap(num => {
          this.countDownDisplay = (--num).toString()
          if (num === 0) {
            this.starterFinished.emit();
          }
        }),
      )
      .subscribe();
    this.subs.push(sub)
  }
}
