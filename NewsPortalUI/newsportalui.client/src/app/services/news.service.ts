import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NewsService {
  private apiUrl = 'https://localhost:7079/api/news';

  constructor(private http: HttpClient) { }

  getNews(apiKey: string): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${apiKey}`);
  }
}
