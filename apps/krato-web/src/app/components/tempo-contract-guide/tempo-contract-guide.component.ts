import { Component, Input } from '@angular/core';

@Component({
  selector: 'kt-tempo-contract-guide',
  standalone: true,
  imports: [],
  templateUrl: './tempo-contract-guide.component.html',
  styleUrl: './tempo-contract-guide.component.scss'
})
export class TempoContractGuideComponent {
  @Input() totalTime!: number;
  @Input() liveTime!: number;
  @Input() isConcentric!: boolean;
  @Input() isReversed!: boolean;

  @Input() eccentricTotal!: number;
  @Input() eccentricGuide!: number;
  @Input() concentricTotal!: number;
  @Input() concentricGuide!: number;

  getEccentricHeight(): string {
    if (this.eccentricTotal === 0) {
      return '0%';
    }
    let percentage = (this.eccentricGuide / this.eccentricTotal) * 100;
    return `${percentage}%`;
  }

  getConcentricHeight(): string {
    if (this.concentricTotal === 0) {
      return '0%';
    }
    let percentage = (this.concentricGuide / this.concentricTotal) * 100;
    percentage = 100 - percentage;
    return `${percentage}%`;
  }

  getBarHeightPercentage(): string {
    if (this.totalTime === 0) {
      return '0%';
    }
    let percentage = (this.liveTime / this.totalTime) * 100;
    if (this.isReversed) {
      percentage = 100 - percentage;
    }
    return `${percentage}%`;
  }
}
