import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Client } from 'src/app/_models/client';
import { Character } from 'src/app/_models/character';
import { Game } from 'src/app/_models/game';
import { Overview } from 'src/app/_models/overview';

@Injectable({
  providedIn: 'root'
})
export class DbndService {

  constructor(private http: HttpClient) { }

  // `https://localhost:44342/api/client`;
  baseUrl: string = `https://dbndapi.azurewebsites.net/api/client`;

// Clients:
  // GET     Get client's id from token: api/client
  getId$(): Observable<any> {
    return this.http.get(`${this.baseUrl}`);
  }

  // GET     Get client info: api/client/{clientId}
  getUser$(clientId: string): Observable<any> {
    return this.http.get(`${this.baseUrl}/${clientId}`);
  }

  // PUT     Update client info: api/client/update/{clientId}
  updateUser$(clientId: string, clientInfo: Client) {
    return this.http.put(`${this.baseUrl}/${clientId}/update`, clientInfo);
  }

// Characters (of a client):
  // POST    Create new character: api/client/{clientId}/characters/new
  createCharacter$(clientId: string, character: Character): Observable<any> {
    return this.http.post(`${this.baseUrl}/${clientId}/characters/new`, character);
  }
  
  // GET     Get all characters: api/client/{clientId}/characters
  getUserCharacters$(clientId: string): Observable<any> {
    return this.http.get(`${this.baseUrl}/${clientId}/characters`);
  }

  // GET     Get character info: api/client/{clientId}/characters/{characterId}
  getCharacter$(clientId: string, characterId: string): Observable<any> {
    return this.http.get(`${this.baseUrl}/${clientId}/characters/${characterId}`);
  }

  // PUT     Update character info: api/client/{clientId}/characters/{characterId}/update
  updateCharacter$(clientId: string, characterId: string, character: Character) {
    return this.http.put(`${this.baseUrl}/${clientId}/characters/${characterId}`, character);
  }

  // DELETE  Delete character: api/client/{clientId}/characters/{characterId}/delete
  deleteCharacter$(clientId: string, characterId: string): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${clientId}/characters/${characterId}/delete`);
  }

// Games (of a client):
  // POST    Create new game: api/client/{clientId}/games/new
  createGame$(clientId: string, game: Game): Observable<any> {
    return this.http.post(`${this.baseUrl}/${clientId}/games/new`, game);
  }
  
  // GET     Get client's games: api/client/{clientId}/games
  getUserGames$(clientId: string): Observable<any> {
    return this.http.get(`${this.baseUrl}/${clientId}/games`);
  }

  // GET     Get game info: api/client/{clientId}/games/{gameId}
  getGame$(clientId: string, gameId: string): Observable<any> {
    return this.http.get(`${this.baseUrl}/${clientId}/games/${gameId}`);
  }

  // PUT     Add character to game: api/client/{clientId}/games/{gameId}/addCharacter/{characterId}
  addCharacterToGame$(clientId: string, gameId: string, characterId: string) {
    return this.http.put(`${this.baseUrl}/${clientId}/games/${gameId}/addCharacter/${characterId}`, null);
  }

  // PUT     Update game info: api/client/{clientId}/games/{gameId}/update
  updateGame$(clientId: string, gameId: string, game: Game) {
    return this.http.put(`${this.baseUrl}/${clientId}/games/${gameId}/update`, game);
  }
  
  // DELETE  Delete game: api/client/{gameId}/games/{gameId}/delete
  deleteGame$(clientId: string, gameId: string): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${clientId}/games/${gameId}/delete`);
  }

// Overviews (of a game):
  // POST    Create overview: api/client/{clientId}/games/{gameId}/overviews/new
  createOverview$(clientId: string, gameId: string, overview: Overview): Observable<any> {
    return this.http.post(`${this.baseUrl}/${clientId}/games/${gameId}/overviews/new`, overview);
  }
  
  // GET     Get all overviews of a game: api/client/{clientId}/games/{gameId}/overviews
  getGameOverviews$(clientId: string, gameId: string): Observable<any> {
    return this.http.get(`${this.baseUrl}/${clientId}/games/${gameId}/overviews`)
  }
  
  // GET     Get overview info: api/client/{clientId}/games/{gameId}/overviews/{overviewId}
  getOverview$(clientId: string, gameId: string, overviewId: string): Observable<any> {
    return this.http.get(`${this.baseUrl}/${clientId}/games/${gameId}/overviews/${overviewId}`)
  }
  
  // PUT     Update overview: api/client/{clientId}/games/{gameId}/overviews/{overviewId}/update
  updateGameOverview$(clientId: string, gameId: string, overviewId: string, overview: Overview) {
    return this.http.put(`${this.baseUrl}/${clientId}/games/${gameId}/overviews/${overviewId}/update`, overview);
  }

  // DELETE  Remove overview: api/client/{clientId}/games/{gameId}/overviews/{overviewId}/delete
  deleteOverview$(clientId: string, gameId: string, overviewId: string): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${clientId}/games/${gameId}/overviews/${overviewId}/delete`);
  }

}
