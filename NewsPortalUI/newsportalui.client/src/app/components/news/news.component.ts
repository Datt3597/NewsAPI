import { Component } from '@angular/core';
import { NewsService } from '../../services/news.service';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.css'],
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule
  ]
})
export class NewsComponent {
  newsData: any[] = [];
  apiKey: string = '';
  isLoading: boolean = false;
  errorMessage: string = '';

  constructor(private newsService: NewsService) { }

  fetchNews() {
    if (!this.apiKey) {
      this.errorMessage = 'Please enter a valid API Key.';
      return;
    }

    this.isLoading = true;
    this.errorMessage = '';

    this.newsService.getNews(this.apiKey).subscribe(
      data => {
        this.newsData = data;
        this.isLoading = false;
      },
      error => {
        this.errorMessage = 'Error fetching news. Please check your API Key.';
        this.isLoading = false;
      }
    );
  }
}
