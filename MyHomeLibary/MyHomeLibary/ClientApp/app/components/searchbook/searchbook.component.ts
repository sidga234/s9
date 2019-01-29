import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { FetchBookComponent } from '../fetchbook/fetchbook.component';
import { LibraryService } from '../../Services/libraryservice.service';
import { searchresult } from '../searchresult/searchresult.component';


@Component({
    selector: 'searchbook',
    templateUrl: './searchbook.component.html'
})

export class searchbook implements OnInit {
   // bookForm: FormGroup;
    title: string = "Search";
    id: number;
    errorMessage: any;
    bookname: "";
    @Input() result: string = "";
    @Output() clicked = new EventEmitter<string>();
    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _libraryService: LibraryService, private _router: Router) {
        if (this._avRoute.snapshot.params["id"]) {
            this.id = this._avRoute.snapshot.params["id"];
        }
    }

    ngOnInit() {
       
    }

    search() {
      
        if (this.title == "Search") {
            this._libraryService.searchByBooks(this.bookname)          
                .subscribe((data) => {
                    this._router.navigate(['/search-result']);
                }, error => this.errorMessage = error)
        }
       
    }

    onClick(searchTerm: string) {
        
        this.clicked.emit(searchTerm);
        this._router.navigate(['/search-result']);
    }
   
    cancel() {
        this._router.navigate(['/fetch-book']);
    }

    
}
