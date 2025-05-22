import { RubiksFace } from "./rubiks-face.enum";
import { RubiksRotation } from "./rubiks-rotation.enum";

export interface RotateCubeDto {
  faceRubikToRotate: RubiksFace;
  rubiksRotation: RubiksRotation;
}
