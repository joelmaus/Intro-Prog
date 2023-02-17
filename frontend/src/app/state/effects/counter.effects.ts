import { Injectable } from "@angular/core";
import { Actions, concatLatestFrom, ofType } from "@ngrx/effects";
import { createEffect } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { catchError, filter, map, of, tap } from "rxjs";
import { selectCounterFeature } from "../index";
import { counterDocuments, counterEvents } from "../actions/counter.actions";
import { CounterState } from "../reducers/counter.reducer";
import { z } from 'zod';
import { applicationEvents } from "../actions/app.actions";
@Injectable()
export class CounterEffects {

    private readonly CountDataSchema = z.object({
        current: z.number(),
        by: z.union([
            z.literal(1),
            z.literal(3),
            z.literal(5)
        ])
    })

    // this will turn counterEvents.counterEntered -> counterDocuments.counter || nothing
    loadCounterPrefs$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(counterEvents.counterEntered), // -> counterEntered Action
            map(() => localStorage.getItem('counter-data')), // string || null
            filter((storedStuff) => storedStuff != null),// stop here if there is nothing stored.
            map((storedStuff) => JSON.parse(storedStuff!)),// { count: 1, by: 3} as CounterState
            map((susObject) => this.CountDataSchema.parse(susObject) as CounterState),
            map((payload: CounterState) => counterDocuments.counter({ payload })),
            catchError((err) => {
                return of(applicationEvents.error({ message: 'WE got ourselves a Mr. Robot wanna be haxx0ring the localstorage!' }))
            })
        )
    }, { dispatch: true })

    saveCounterPrefs$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(counterEvents.countBySet, counterEvents.countDecremented, counterEvents.countIncremented, counterEvents.countReset),
            concatLatestFrom(() => this.store.select(selectCounterFeature)),
            tap(([_, data]) => localStorage.setItem('counter-data', JSON.stringify(data)))
        )
    }, { dispatch: false })

    // logItall$ = createEffect(() => {
    //     return this.actions$.pipe(
    //         tap(a => console.log(`Got an action of type ${a.type}`))

    //     )
    // }, { dispatch: false })

    constructor(private actions$: Actions, private store: Store) { }
}