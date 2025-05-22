import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RubiksCubeDto } from '../../models/rubikscube/rubikscubeDto.model';
import { environment } from '../../../../envirionment';
import { RotateCubeDto } from '../../models/rubikscube/rotateCubeDto.model';

@Injectable({ providedIn: 'root' })
export class RubiksCubeService {
  private baseUrl = `${environment.apiBaseUrl}/rubik`;

  constructor(private http: HttpClient) { }

  getCube(id: string): Observable<RubiksCubeDto> {
    return this.http.get<RubiksCubeDto>(`${this.baseUrl}/${id}`);
  }

  getAllCubes(): Observable<RubiksCubeDto[]> {
    return this.http.get<RubiksCubeDto[]>(`${this.baseUrl}`);
  }

  rotateCube(id: string, rotateCubeDto: RotateCubeDto): Observable<RubiksCubeDto> {
    return this.http.post<RubiksCubeDto>(`${this.baseUrl}/rotate/${id}`, rotateCubeDto);
  }

  createCube(): Observable<RubiksCubeDto> {
    return this.http.post<RubiksCubeDto>(`${this.baseUrl}/create`, null);
  }
}
