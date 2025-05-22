import { Component, OnInit } from "@angular/core";
import { filter, map, takeUntil } from "rxjs";
import { BaseComponent } from "../../shared/components/base.component";
import { ActivatedRoute, NavigationEnd, Router } from "@angular/router";
import { Store } from "@ngrx/store";
import { clearCubeError, loadAllCubes } from "./store/rubikscube/rubikscube.action";
import { selectRubiksCubeError } from "./store/rubikscube/rubikscube.selector";
import { MatSnackBar } from "@angular/material/snack-bar";

@Component({
  selector: 'rubikscube',
  templateUrl: './rubikscube.component.html',
  styleUrls: ['./rubikscube.component.scss']
})
export class RubiksCubeComponent extends BaseComponent implements OnInit {
  pageTitle = '';

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private store: Store,
    private snackBar: MatSnackBar) {
    super();
  }

  ngOnInit(): void {
    this.router.events
      .pipe(
        filter(event => event instanceof NavigationEnd),
        map(() => {
          let route = this.route.firstChild;
          while (route?.firstChild) {
            route = route.firstChild;
          }
          return route?.snapshot.data['title'] || '';
        }),
        takeUntil(this.destroy$)
      )
      .subscribe(title => {
        this.pageTitle = title;
      });
    this.store.select(selectRubiksCubeError)
      .pipe(takeUntil(this.destroy$))
      .subscribe((error) => {
        if (error) {
          this.snackBar.open(error, 'Close');
          this.store.dispatch(clearCubeError());
        }
      });
    this.store.dispatch(loadAllCubes());
  }

}
