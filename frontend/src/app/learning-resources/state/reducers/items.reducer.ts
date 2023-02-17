import { EntityState, createEntityAdapter } from '@ngrx/entity';
import { createReducer, Action, on } from '@ngrx/store';
import { itemsDocuments } from '../actions/items.actions';

export interface ItemEntity {
    id: string;
    description: string;
    type: ItemType;
    link: string;
}


export type ItemType = 'Book' | 'Video' | 'Blog' | 'Tutorial' | 'Other';
export interface ItemState extends EntityState<ItemEntity> {

}

export const adapter = createEntityAdapter<ItemEntity>();

const initialState = adapter.getInitialState();

export const reducer = createReducer(
    initialState,
    on(itemsDocuments.items, (s, a) => adapter.setAll(a.payload, s)), // adds the data to the state. It is in memory now!
    on(itemsDocuments.item, (s, a) => adapter.addOne(a.payload, s))
);

