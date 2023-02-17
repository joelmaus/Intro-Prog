import { createActionGroup, props } from "@ngrx/store";
import { ItemEntity } from "../reducers/items.reducer";

export const itemsEvents = createActionGroup({
    source: 'Items Events',
    events: {
        created: props<{ payload: ItemCreate }>(), // form
    }
})


export const itemsDocuments = createActionGroup({
    source: 'Items Documents',
    events: {
        items: props<{ payload: ItemEntity[] }>(),
        item: props<{ payload: ItemEntity }>() // our effect is going to turn the created action into by calling the api.
    }
})

export type ItemCreate = Omit<ItemEntity, 'id'>;