export class Championship {
  description: string = '';
  finishingDate: string = '';
  finishingTime: string = '';
  id: string = '';
  name: string = '';
  startingDate: string = '';
  startingTime: string = '';
}

export class Race {
  id: number = 0;
  championshipId: string = '';
  name: string = '';
  country: string = '';
  trackName: string = '';
  actualState: string = '';
  startingDate: string = '';
  finishingDate: string = '';
  startingTime: string = '';
  finishingTime: string = '';
}

export class RaceAux extends Race {
  championshipName: string = '';
}
export class Country {
  name: string = '';
  code: string = '';
}
