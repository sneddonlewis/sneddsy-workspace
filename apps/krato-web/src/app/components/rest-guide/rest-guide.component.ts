import { Component, Input } from '@angular/core';

@Component({
  selector: 'kt-rest-guide',
  standalone: true,
  imports: [],
  templateUrl: './rest-guide.component.html',
  styleUrl: './rest-guide.component.scss'
})
export class RestGuideComponent {
  @Input({ required: true}) totalTime!: number;
  @Input({ required: true}) liveTime!: number;
}
