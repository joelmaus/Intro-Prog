import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { selectCounterCurrent } from 'src/app/state';
import { counterEvents } from 'src/app/state/actions/counter.actions';

@Component({
  selector: 'app-counter',
  templateUrl: './counter.component.html',
  styleUrls: ['./counter.component.css']
})
export class CounterComponent {



  current$ = this.store.select(selectCounterCurrent)
  constructor(private store: Store) {

  }



  increment() {
    this.store.dispatch(counterEvents.countIncremented())
  }

  decrement() {
    this.store.dispatch(counterEvents.countDecremented())
  }

  reset() {
    this.store.dispatch(counterEvents.countReset());
  }
}
