import { ActionReducerMap, createFeatureSelector, createSelector } from "@ngrx/store";
import { from } from "rxjs";
import * as fromItems from './reducers/items.reducer';
export const featureName = "resources";

export interface FeatureInterface {
    items: fromItems.ItemState
}

export const reducers: ActionReducerMap<FeatureInterface> = {
    items: fromItems.reducer
};


// 1. Feature Select
const selectFeature = createFeatureSelector<FeatureInterface>(featureName);


// 2. Selector per branch of the feature (1 - items)
// "Functional Composition"
const selectItemsBranch = createSelector(selectFeature, f => f.items);


// 3. Helpers


// 4. What our component needs.
export const { selectAll: selectItemsArray } = fromItems.adapter.getSelectors(selectItemsBranch);




