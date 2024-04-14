import { Routes } from '@angular/router';
import { TempoTimerComponent } from './components/tempo-timer/tempo-timer.component';
import { TempoTimerListComponent } from './components/tempo-timer-list/tempo-timer-list.component';

export const appRoutes: Routes = [
    { path: '', component: TempoTimerListComponent },
    { path: 'tempo-timer', component: TempoTimerComponent },
  ];
  
  export const routePaths = {
    home: '/',
    timer: '/timer',
    tempoTimer: '/tempo-timer'
  } as const;