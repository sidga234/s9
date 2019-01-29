import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class LibraryService {
    myAppUrl: string = "";

    constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = baseUrl;
    }

    getBooks() {
        
        return this._http.get(this.myAppUrl + 'api/Library/Index')
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    getTypes() {
        return this._http.get(this.myAppUrl + 'api/Library/GetAllTypes')
            .map((response: Response) => response.json())
            .catch(this.errorHandler);


    }

    getLanguage() {
        return this._http.get(this.myAppUrl + 'api/Library/GetAllLanguages')
            .map((response: Response) => response.json())
            .catch(this.errorHandler);


    }

    getClasss() {
        return this._http.get(this.myAppUrl + 'api/Library/GetAllClasss')
            .map((response: Response) => response.json())
            .catch(this.errorHandler);


    }

    getBookById(id: number) {
        return this._http.get(this.myAppUrl + "api/Library/Details/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }
    searchByBooks(_searchBookName: string) {
     
        return this._http.get(this.myAppUrl + 'api/Library/SearchByBookName/' + _searchBookName)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }
    saveBooks(books) {
        return this._http.post(this.myAppUrl + 'api/Library/Create', books)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    updateBooks(books) {
        return this._http.put(this.myAppUrl + 'api/Library/Edit', books)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    deleteBooks(id) {
        return this._http.delete(this.myAppUrl + "api/Library/Delete/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    errorHandler(error: Response) {
        console.log(error);
        return Observable.throw(error);
    }
}