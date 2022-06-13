import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ValidationService {

  constructor() { }

  fieldIsEmpty(field: string): boolean {
    if (field.trim() == '')
      return true;
    
    return false;
  }

  fieldContainsDigits(field: string): boolean {
    if (field.match(/[0-9]/) != null)
      return true;

    return false;
  }
}
