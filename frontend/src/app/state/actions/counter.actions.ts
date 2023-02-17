import { createActionGroup, emptyProps, props } from "@ngrx/store";
import { CounterState } from "../reducers/counter.reducer";


export const counterEvents = createActionGroup({
    source: 'Counter Events',
    events: {
        'Count Incremented': emptyProps(),
        'Count Decremented': emptyProps(),
        'Count Reset': emptyProps(),
        'Count By Set': props<{ by: CountByValues }>(),
        'Counter Entered': emptyProps()
    }
})

export const counterDocuments = createActionGroup({
    source: 'Counter Documents',
    events: {
        'counter': props<{ payload: CounterState }>()
    }
})

export type CountByValues = 1 | 3 | 5;