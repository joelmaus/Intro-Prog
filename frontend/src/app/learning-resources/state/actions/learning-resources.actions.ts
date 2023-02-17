import { createActionGroup, emptyProps } from "@ngrx/store";


export const learingResourcesEvents = createActionGroup({
    source: 'Learning Resources Events',
    events: {
        entered: emptyProps()
    }
})