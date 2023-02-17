import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { concatMap, map, switchMap } from "rxjs";
import { itemsDocuments, itemsEvents } from "../actions/items.actions";
import { learingResourcesEvents } from "../actions/learning-resources.actions";
import { ItemEntity } from "../reducers/items.reducer";


@Injectable()
export class ItemsEffects {

    addItem$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(itemsEvents.created),
            concatMap((a) => this.client.post<ItemEntity>('http://localhost:1337/resources', a.payload)
                .pipe(
                    map(payload => itemsDocuments.item({ payload }))
                )
            )
        )
    })

    loadItemsOnFeatureEntered$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(learingResourcesEvents.entered),
            switchMap(() => this.client.get<ItemResponseFromServer>('http://localhost:1337/resources')
                .pipe(
                    map(response => response.items), // { items: []} => []
                    map(payload => itemsDocuments.items({ payload }))
                )

            )
        )
    })

    constructor(private actions$: Actions, private client: HttpClient) { }
}

type ItemResponseFromServer = {
    items: ItemEntity[]
}