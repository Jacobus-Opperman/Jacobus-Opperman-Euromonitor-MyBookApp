import { Component, OnInit, ViewChild } from '@angular/core';
import { BookService } from '../book.service';
import { SubscriptionComponent } from '../subscription/subscription.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  books: any[] = [];

  @ViewChild(SubscriptionComponent) subscriptionComponent!: SubscriptionComponent;

  constructor(private bookService: BookService) {}

  ngOnInit(): void {
    this.selectBooks();
  }

  onLike(bookId: number): void {
    this.bookService.subscribeBook(bookId).subscribe(
      (response) => {
        console.log('Book subscribed successfully', response);
        this.selectBooks();
        this.subscriptionComponent.selectSubscriptions();
      },
      (error) => {
        console.error('Error subscribing to book', error);
      }
    );
  }

  selectBooks(): void {
    this.bookService.getBooks().subscribe((data) => {
      this.books = data;
    });
  }

  onUnsubscribed(): void{
    this.selectBooks();
  }
}
