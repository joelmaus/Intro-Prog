import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-shopping-list',
  templateUrl: './shopping-list.component.html',
  styleUrls: ['./shopping-list.component.css']
})
export class ShoppingListComponent {

  form = new FormGroup({
    item: new FormControl<string>('', { nonNullable: true })
  });
  // state - data
  items: ShoppingItem[] = [
    { description: 'Beer', purchased: false },
    { description: 'Buns', purchased: false },
    { description: 'Eggs', purchased: true }
  ];


  clearPurchased() {
    this.items = this.items.filter(item => item.purchased === false);
  }

  get hasPurchasedItems() {
    return this.items.filter(item => item.purchased).length > 0;
  }
  // behavior - methods
  markPurchased(item: ShoppingItem) {
    item.purchased = true;
  }

  addItem() {

    const description = this.form.controls.item.value;
    const newItem: ShoppingItem = {
      description: description,
      purchased: false
    }

    this.items = [newItem, ...this.items];

  }
}

type ShoppingItem = {
  description: string,
  purchased: boolean
}