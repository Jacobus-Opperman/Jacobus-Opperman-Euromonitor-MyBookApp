import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { BookService } from '../book.service';

@Component({
  selector: 'app-subscription',
  templateUrl: './subscription.component.html',
  styleUrls: ['./subscription.component.css']
})
export class SubscriptionComponent implements OnInit {
  subscriptions: any[] = [];

  @Output() unsubscribed = new EventEmitter<void>();

  constructor(private bookService: BookService) {}

  ngOnInit(): void {
    this.selectSubscriptions();
  }

  unsubscribe(bookId: number): void {
    this.bookService.unsubscribeBook(bookId).subscribe(() => {
      this.subscriptions = this.subscriptions.filter((book) => book.id !== bookId);
      this.unsubscribed.emit();
    });
  }

  selectSubscriptions(): void {
    this.bookService.getSubscriptions().subscribe((data) => {
      this.subscriptions = data;
    });
  }
}
