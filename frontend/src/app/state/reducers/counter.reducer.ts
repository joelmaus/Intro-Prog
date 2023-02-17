
// tell typescript about it

import { createReducer, on } from "@ngrx/store";
import { CountByValues, counterDocuments, counterEvents } from "../actions/counter.actions";

export interface CounterState {
    current: number;
    by: CountByValues
}

// What should this have when the application starts up? 

const initialState: CounterState = {
    current: 0,
    by: 1
}

// write a function that is responsible for this branch of the application state.
// this function gets a read-only copy of the current state, and any actions that have been dispatched
// and it can return a new state.

export const reducer = createReducer(
    initialState,
    on(counterEvents.countIncremented, (currentState) => ({ ...currentState, current: currentState.current + currentState.by })),
    on(counterEvents.countDecremented, (s) => ({ ...s, current: s.current - s.by })),
    on(counterEvents.countReset, (s) => ({ ...s, current: 0 })),
    on(counterEvents.countBySet, (s, a) => ({ ...s, by: a.by })),
    on(counterDocuments.counter, (s, a) => a.payload)
);