import { Component, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CountryService } from '../services/country.service';

@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrl: './country.component.scss',
})
export class CountryComponent {
  CountryForm = new FormGroup({
    name: new FormControl('', Validators.required),
  });

  Country: string;
  visible: boolean = false;

  countries: any = [];
  dialogHeader: string = '';

  constructor(private countryService: CountryService) {
    this.getAllCountries();
  }

  ngOnInit() {}

  getAllCountries() {
    this.countryService.getAll().subscribe(result => {
      debugger;
      this.countries = result.items;
    });
  }

  onCountryDelete(id: string) {
    this.countryService.delete(id).subscribe(result => {
      debugger;
      this.getAllCountries();
    });
  }

  onCountryForm() {
    this.dialogHeader = 'Add New Country';
    this.visible = !this.visible;
  }

  OnCountrySubmit() {
    debugger;
    if (this.CountryForm.valid) {
      this.countryService.add(this.CountryForm.value).subscribe(result => {
        debugger;
        this.getAllCountries();
        this.visible = !this.visible;
        this.CountryForm.reset();
      });
    } else {
      this.CountryForm.touched;
    }
  }

  hideDialogEvent(hide: boolean) {}
}
