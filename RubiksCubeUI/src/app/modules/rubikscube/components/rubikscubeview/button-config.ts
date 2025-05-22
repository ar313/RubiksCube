import { RubiksFace } from "../../../../models/rubikscube/rubiks-face.enum";
import { RubiksRotation } from "../../../../models/rubikscube/rubiks-rotation.enum";

export interface ButtonConfig {
  sort: number;
  label: string;
  face: RubiksFace;
  rotation: RubiksRotation;
}

export const BuildButtons = (): ButtonConfig[] => {
  return [
    {
      sort: 0,
      label: 'F',
      face: RubiksFace.Front,
      rotation: RubiksRotation.Clockwise,
    },
    {
      sort: 1,
      label: 'R',
      face: RubiksFace.Right,
      rotation: RubiksRotation.Clockwise,
    },
    {
      sort: 2,
      label: 'U',
      face: RubiksFace.Up,
      rotation: RubiksRotation.Clockwise,
    },
    {
      sort: 3,
      label: 'B',
      face: RubiksFace.Back,
      rotation: RubiksRotation.Clockwise,
    }
    ,
    {
      sort: 4,
      label: 'L',
      face: RubiksFace.Left,
      rotation: RubiksRotation.Clockwise,
    }
    ,
    {
      sort: 5,
      label: 'D',
      face: RubiksFace.Down,
      rotation: RubiksRotation.Clockwise,
    }
    ,
    {
      sort: 6,
      label: 'F\'',
      face: RubiksFace.Front,
      rotation: RubiksRotation.CounterClockwise,
    },
    {
      sort: 7,
      label: 'R\'',
      face: RubiksFace.Right,
      rotation: RubiksRotation.CounterClockwise,
    },
    {
      sort: 8,
      label: 'U\'',
      face: RubiksFace.Up,
      rotation: RubiksRotation.CounterClockwise,
    },
    {
      sort: 9,
      label: 'B\'',
      face: RubiksFace.Back,
      rotation: RubiksRotation.CounterClockwise,
    }
    ,
    {
      sort: 10,
      label: 'L\'',
      face: RubiksFace.Left,
      rotation: RubiksRotation.CounterClockwise,
    }
    ,
    {
      sort: 11,
      label: 'D\'',
      face: RubiksFace.Down,
      rotation: RubiksRotation.CounterClockwise,
    }
  ];
}
