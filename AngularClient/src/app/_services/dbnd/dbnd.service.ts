import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DbndService {

  constructor(private http: HttpClient) { }

  getId$(): Observable<any> {
    return this.http.get('https://dbndapi.azurewebsites.net/api/client/');
  }

  getUser$(clientId: string): Observable<any> {
    return this.http.get(`https://dbndapi.azurewebsites.net/api/client/${clientId}/`);
  }

	//PUT     Update client info: api/clients/update/{clientId}

// Characters (of a client):
  // POST    Create new character: api/clients/{clientId}/characters/new
  
  // GET     Get all characters: api/clients/{clientId}/characters
  getUserCharacters$(clientId: string): Observable<any> {
    return this.http.get(`https://dbndapi.azurewebsites.net/api/client/${clientId}/characters/`)
  }

  // GET     Get character info: api/clients/{clientId}/characters/{characterId}
  getCharacter$(clientId: string, characterId: string): Observable<any> {
    return this.http.get(`https://dbndapi.azurewebsites.net/api/client/${clientId}/characters/${characterId}`)
  }

  // PUT     Update character info: api/clients/{clientId}/characters/{characterId}/update
  
	// DELETE  Delete character: api/clients/{clientId}/characters/{characterId}/delete

// Games (of a client):
  // POST    Create new game: api/clients/{clientId}/games/new
  
  // GET     Get client's games: api/clients/{clientId}/games
  getUserGames$(clientId: string): Observable<any> {
    return this.http.get(`https://dbndapi.azurewebsites.net/api/clients/${clientId}/games`)
  }

  // GET     Get game info: api/clients/{clientId}/games/{gameId}
  getGame$(clientId: string, gameId: string): Observable<any> {
    return this.http.get(`https://dbndapi.azurewebsites.net/api/clients/${clientId}/games/${gameId}`)
  }

	// PUT     Add character to game: api/clients/{clientId}/games/{gameId}/addCharacter/{characterId}
	// PUT     Update game info: api/clients/{clientId}/games/{gameId}/update
	// DELETE  Delete game: api/clients/{clientId}/games/{gameId}/delete

// Overviews (of a game):
  // POST    Create overview: api/clients/{clientId}/games/{gameId}/overviews/new
  
  // GET     Get all overviews of a game: api/clients/{clientId}/games/{gameId}/overviews
  getGameOverviews$(clientId: string, gameId: string): Observable<any> {
    return this.http.get(`https://dbndapi.azurewebsites.net/api/clients/${clientId}/games/${gameId}/overviews`)
  }
  
  // GET     Get overview info: api/clients/{clientId}/games/{gameId}/overviews/{overviewId}
  getOverview$(clientId: string, gameId: string, overviewId: string): Observable<any> {
    return this.http.get(`https://dbndapi.azurewebsites.net/api/clients/${clientId}/games/${gameId}/overviews/${overviewId}`)
  }
  
  // PUT     Update overview: api/clients/{clientId}/games/{gameId}/overviews/{overviewId}/update
  
	// DELETE  Remove overview: api/clients/{clientId}/games/{gameId}/overviews/{overviewId}/delete

}
