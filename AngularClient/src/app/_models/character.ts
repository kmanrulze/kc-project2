import { Game } from './game';

export class Character {
    constructor() { }

    public CharacterID: string;
    public ClientID: string;
    public FirstName: string;
    public LastName: string;
    public Games: Game[];
}
