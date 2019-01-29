import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { FetchBookComponent } from '../fetchbook/fetchbook.component';
import { LibraryService } from '../../Services/libraryservice.service';

@Component({
    selector: 'createbook',
    templateUrl: './AddBooks.Component.html'
})

export class createbook implements OnInit {
    bookForm: FormGroup;
    title: string = "Create";
    id: number;
    errorMessage: any;
    public classlist: ClassList[];
    public typelist: TypeList[];
    public languagelist: LanguageList[];
    public selectedclass;

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _libraryService: LibraryService, private _router: Router) {
        if (this._avRoute.snapshot.params["id"]) {
            this.id = this._avRoute.snapshot.params["id"];
           
        }

        this.bookForm = this._fb.group({
            id: 0,
            bookName: ['', [Validators.required]],
            authorName: ['', [Validators.required]],
            class: ['', [Validators.required]],
            publisher: ['', [Validators.required]],
            dateOfPurchase: ['', [Validators.required]],
            language: ['', [Validators.required]],
            type: ['', [Validators.required]],
            price: ['', [Validators.required]]        
        })
    }

    ngOnInit() {
        if (this.id > 0) {
            this.title = "Edit";
            this._libraryService.getBookById(this.id)
                .subscribe(resp => this.bookForm.setValue(resp)
                , error => this.errorMessage = error);
        }
        this.getClasss();
        this.getTypes();
        this.getLanguage();
    }

    save() {
        if (!this.bookForm.valid) {
            return;
        }

        if (this.title == "Create") {
            this._libraryService.saveBooks(this.bookForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-book']);
                }, error => this.errorMessage = error)
        }
        else if (this.title == "Edit") {
            this._libraryService.updateBooks(this.bookForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-book']);
                }, error => this.errorMessage = error)
        }
    }

    cancel() {
        this._router.navigate(['/fetch-book']);
    }

    getClasss() {
        this._libraryService.getClasss().subscribe(
            data => this.classlist = data

        )
    }

    getTypes() {
        this._libraryService.getTypes().subscribe(
            data => this.typelist = data

        )
    }

    getLanguage() {
        this._libraryService.getLanguage().subscribe(
            data => this.languagelist = data
        )
    }


    get bookName() { return this.bookForm.get('bookName'); }
    get authorName() { return this.bookForm.get('authorName'); }
    get price() { return this.bookForm.get('price'); }
    get class() { return this.bookForm.get('class'); }
    get publisher() { return this.bookForm.get('publisher'); }
    get dateOfPurchase() { return this.bookForm.get('dateOfPurchase'); }
    get language() { return this.bookForm.get('language'); }
    get type() { return this.bookForm.get('type'); }
}

interface ClassList {
    classId: number;
    class: string;
}

interface TypeList {
    type: string;   typeId: number;
}

interface LanguageList {
    language: string; languageId: number;
}