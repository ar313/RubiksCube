import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RubiksCubesListComponent } from './components/rubikscubeslist/rubikscubes-list.component';
import { RubiksCubeExplodedViewComponent } from './components/rubikscubeview/rubikscube-exploded-view.component';
import { RubiksCubeComponent } from './rubikscube.component';

const routes: Routes = [
  {
    path: '',              
    component: RubiksCubeComponent,
    children: [{
        path: '',
        redirectTo: 'view',
        pathMatch: 'full'
      },
      {
        path: 'view',
        component: RubiksCubesListComponent,
        data: { title: 'Rubiks Cube List' }
      },
      {
        path: 'view/:id',
        component: RubiksCubeExplodedViewComponent,
        data: { title: 'Rubiks Cube Exploded View' }
      }
    ]
  },
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class RubiksCubesRoutingModule { }

