import { RubiksColor } from "./rubiks-color.enum";
import { RubiksFace } from "./rubiks-face.enum";

export interface RubiksBoxDto {
  id: string;
  face: RubiksFace,
  row: number;
  column: number;
  color: RubiksColor;
  rubiksCubeId: string;
}

