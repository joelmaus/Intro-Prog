import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { ItemCreate, itemsEvents } from '../../state/actions/items.actions';
import { ItemType } from '../../state/reducers/items.reducer';

@Component({
  selector: 'app-new',
  templateUrl: './new.component.html',
  styleUrls: ['./new.component.css']
})
export class NewComponent {

  constructor(private store: Store) { }
  options = ['Book', 'Video', 'Blog', 'Tutorial', 'Other'];

  form = new FormGroup<ItemCreateForm>({
    description: new FormControl<string>('', {
      nonNullable: true,
      validators: [
        Validators.required
      ]
    }),
    type: new FormControl<ItemType>('Other', { nonNullable: true }),
    link: new FormControl<string>('', {
      nonNullable: true,
      validators: [
        Validators.required,
        Validators.maxLength(50),
        Validators.minLength(5)
      ]
    })

  });

  get description() { return this.form.controls.description; }
  get type() { return this.form.controls.type; }
  get link() { return this.form.controls.link; }

  addItem(foci: HTMLInputElement) {
    if (this.form.valid) {
      // dispatch our action!
      const payload = this.form.value as ItemCreate;
      this.store.dispatch(itemsEvents.created({ payload }))
      this.form.reset();
      foci.focus();

    } else {
      //
    }

  }
}



type FormDataType<T> = {
  [Property in keyof T]: FormControl<T[Property]>
}

type ItemCreateForm = FormDataType<ItemCreate>;

// export type ItemType = 'Book' | 'Video' | 'Blog' | 'Tutorial' | 'Other';

