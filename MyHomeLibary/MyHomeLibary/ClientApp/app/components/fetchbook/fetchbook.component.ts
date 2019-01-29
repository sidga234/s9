import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { LibraryService } from '../../Services/libraryservice.service'

@Component({
    selector: 'fetchbook',
    templateUrl: './fetchbook.component.html'
})
export class FetchBookComponent {
    public bookList: BooksData[];

    constructor(public http: Http, private _router: Router, private _libraryService: LibraryService) {
        this.getBooks();
    }

    getBooks() {
        this._libraryService.getBooks().subscribe(
            data => this.bookList = data
            
        )
    }

    delete(bookID) {
        var ans = confirm("Do you want to delete book : " + bookID);
        if (ans) {
            this._libraryService.deleteBooks(bookID).subscribe((data) => {
                this.getBooks();
            }, error => console.error(error))
        }
    }
}

interface BooksData {
    ID: number;
    BookName: string;
    AuthorName: string;
    Class: string;
    Publisher: string;
    DateOfPurchase: string;
    Language: string;
    Type: string;
    Price: number;
}

