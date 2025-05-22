import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [

  {
    path: '',
    redirectTo: 'rubikscube',
    pathMatch: 'full',
  },
  {
    path: 'rubikscube',
    loadChildren: () => import('@modules/rubikscube/rubikscubes.module').then(m => m.RubiksCubesModule)
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
