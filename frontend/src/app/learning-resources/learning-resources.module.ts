import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LearningResourcesComponent } from './learning-resources.component';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ListComponent } from './components/list/list.component';
import { NewComponent } from './components/new/new.component';
import { featureName, reducers } from './state';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { ItemsEffects } from './state/effects/items.effects';
import { ReactiveFormsModule } from '@angular/forms';


const routes: Routes = [
  {
    path: '',
    component: LearningResourcesComponent,
    children: [
      {
        path: 'overview',
        component: DashboardComponent
      },
      {
        path: 'list',
        component: ListComponent
      },
      {
        path: 'new',
        component: NewComponent
      },
      {
        path: '**',
        redirectTo: 'overview'
      }
    ]
  }
]

@NgModule({
  declarations: [
    LearningResourcesComponent,
    DashboardComponent,
    ListComponent,
    NewComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    StoreModule.forFeature(featureName, reducers),
    EffectsModule.forFeature([ItemsEffects]),
    ReactiveFormsModule
  ]
})
export class LearningResourcesModule { }
