import { Injectable } from '@angular/core';
import { BehaviorSubject, interval, map, Observable, Subscription, takeWhile } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TimerService {
  private timerSubscription: Subscription | null = null;
  private timerValue = 0;
  private isRunning = false;
  private timerSubject = new BehaviorSubject<number>(0);

  readonly time$ = this.timerSubject.asObservable();

  getCountdown(from: number): Observable<number> {
    return this.time$
      .pipe(
        map(elapsed => from - elapsed),
        takeWhile(time => time >= 0),
      );
  }

  start() {
    if (!this.isRunning) {
      this.isRunning = true;
      if (!this.timerSubscription || this.timerSubscription.closed) {
        this.timerSubscription = interval(10).pipe(
          takeWhile(() => this.isRunning)
        ).subscribe({
          next: () => {
            this.timerValue++;
            this.timerSubject.next(this.timerValue);
          },
          complete: () => {
            this.isRunning = false;
            this.timerValue = 0;
            this.timerSubject.next(this.timerValue);
          }
        });
      }
    }
  }

  pause() {
    if (this.timerSubscription) {
      this.isRunning = false;
      this.timerSubscription.unsubscribe();
      this.timerSubscription = null;
    }
  }

  resume() {
    this.start();
  }

  stop() {
    if (this.timerSubscription) {
      this.isRunning = false;
      this.timerSubscription.unsubscribe();
      this.timerSubscription = null;
      this.timerValue = 0;
      this.timerSubject.next(this.timerValue);
    }
  }
}
