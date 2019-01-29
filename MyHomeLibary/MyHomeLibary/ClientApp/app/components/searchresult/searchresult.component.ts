import { Component, Inject,Input } from '@angular/core';
import { Http } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { LibraryService } from '../../Services/libraryservice.service'
import { searchbook } from '../searchbook/searchbook.component';
@Component({
    selector: 'searchresult',
    templateUrl: './searchresult.component.html'
})
export class searchresult {
    public bookList: BooksData[];
    title: string = "Search";
    value: string = "Book Information";
    errorMessage: any;
    constructor(public http: Http, private _router: Router, private _libraryService: LibraryService) {
        //this.getBooks();
    }
    getBooks() {
        this._libraryService.getBooks().subscribe(
            data => this.bookList = data

        )
    } 

    ngOnInit() {
        this.getBooks();
        
    }

    search(value) {
      
        if (this.title == "Search") {
            this._libraryService.searchByBooks(value)          
                .subscribe((data) => {
                    this.bookList = data
                }, error => this.errorMessage = error)
        }
       
    }

    onClicked(value: string) {
        if (value != '') {
            this.search(value);
            //this.allProduct = this.allProduct.filter(res => res.pname.startsWith(value));
        }
        else {
            this.getBooks();
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

