// calculator.component.ts

import { Component } from '@angular/core';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.css'],
})
export class CalculatorComponent {
  result: number | null = null;

  compute() {
    const num1 = parseFloat(
      (<HTMLInputElement>document.getElementById('num1')).value
    );
    const num2 = parseFloat(
      (<HTMLInputElement>document.getElementById('num2')).value
    );
    const operation = (<HTMLSelectElement>document.getElementById('operation'))
      .value;

    switch (operation) {
      case 'add':
        this.result = num1 + num2;
        break;
      case 'subtract':
        this.result = num1 - num2;
        break;
      case 'multiply':
        this.result = num1 * num2;
        break;
      default:
        this.result = null;
    }
  }
}
