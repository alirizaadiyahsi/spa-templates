import { Observable } from 'rxjs/Rx';
import { Inject } from '@angular/core';

export abstract class BaseService {

    @Inject('BASE_URL') baseUrl: string;

    constructor() { }

    protected handleError(error: any) {
        const applicationError = error.headers.get('Application-Error');

        // either applicationError in header or model error in body
        if (applicationError) {
            return Observable.throw(applicationError);
        }

        var modelStateErrors: null | string = '';
        const serverError = error.json();

        if (!serverError.type) {
            for (var key in serverError) {
                if (serverError[key]) {
                    modelStateErrors += serverError[key] + '\n';
                }
            }
        }

        modelStateErrors = modelStateErrors === '' ? null : modelStateErrors;
        return Observable.throw(modelStateErrors || 'Server error');
    }
}