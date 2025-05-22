import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { HttpClientModule } from '@angular/common/http';
import { rubiksCubeReducer } from './store/rubikscube/rubikscube.reducer';
import { RubiksCubeEffects } from './store/rubikscube/rubikscube.effects';
import { RubiksCubesListComponent } from './components/rubikscubeslist/rubikscubes-list.component';
import { RubiksCubesRoutingModule } from './rubikscubes-routing.module';
import { MaterialModule } from '@shared/material/material.module';
import { RubiksCubeExplodedViewComponent } from './components/rubikscubeview/rubikscube-exploded-view.component';
import { RubiksCubeFaceComponent } from './components/rubikscubeface/rubikscube-face.component';
import { RubiksCubeComponent } from './rubikscube.component';

@NgModule({
  declarations: [
    RubiksCubeComponent,
    RubiksCubesListComponent,
    RubiksCubeExplodedViewComponent,
    RubiksCubeFaceComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    MaterialModule,
    RubiksCubesRoutingModule,
    StoreModule.forFeature('rubiksCubeState', rubiksCubeReducer ),
    EffectsModule.forFeature([RubiksCubeEffects]),
  ],
  exports: [RubiksCubeComponent]
})
export class RubiksCubesModule { }
