import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { selectCounterCountingBy } from 'src/app/state';
import { CountByValues, counterEvents } from 'src/app/state/actions/counter.actions';

@Component({
  selector: 'app-counter-prefs',
  templateUrl: './counter-prefs.component.html',
  styleUrls: ['./counter-prefs.component.css']
})
export class CounterPrefsComponent {

  by$ = this.store.select(selectCounterCountingBy);
  constructor(private store: Store) { }

  setCountBy(by: CountByValues) {
    this.store.dispatch(counterEvents.countBySet({ by }))
  }
}
