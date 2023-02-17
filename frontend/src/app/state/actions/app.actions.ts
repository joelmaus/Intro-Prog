import { createActionGroup, props } from "@ngrx/store";

export const applicationEvents = createActionGroup({
    source: 'Application Events',
    events: {
        'error': props<{ message: string }>()
    }
})