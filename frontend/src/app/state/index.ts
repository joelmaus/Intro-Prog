

// The "Application State"

import { ActionReducerMap, createFeatureSelector, createSelector } from "@ngrx/store";
import * as fromCounter from './reducers/counter.reducer'

export interface AppState {
    counter: fromCounter.CounterState
};


export const reducers: ActionReducerMap<AppState> = {
    counter: fromCounter.reducer
}
// 1. create a "feature selector"

export const selectCounterFeature = createFeatureSelector<fromCounter.CounterState>('counter');
// 2. Create a selector per branch of the state


// 3. Any helpers (optional)



// 4. What does the component need
// 4.1 We need a selector that returns the current of the counter.

export const selectCounterCurrent = createSelector(
    selectCounterFeature,
    (f => f.current)
)
export const selectCounterCountingBy = createSelector(
    selectCounterFeature,
    f => f.by
)