import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  private apiUrl = 'https://localhost:7067/api';

  constructor(private http: HttpClient) {}

  getBooks(): Observable<any> {
    return this.http.get(`${this.apiUrl}/books`);
  }

  getSubscriptions(): Observable<any> {
    return this.http.get(`${this.apiUrl}/subscriptions`);
  }
  
  subscribeBook(bookId: number): Observable<any> {
    return this.http.post(`${this.apiUrl}/Books/${bookId}/subscription`,bookId);
  }

  unsubscribeBook(bookId: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/subscriptions/${bookId}`);
  }
}
