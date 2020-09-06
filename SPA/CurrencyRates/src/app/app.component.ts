import { Component, OnInit } from '@angular/core';
import Service from './service';
import CurrencyRate from './CurrencyRate';

export class Selection {
  id: string;
  name: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'CurrencyRates';
  dates: Array<Selection>;
  currencies: Array<Selection>;
  selectedDate: string;
  selectedCurrency: string;
  printedText: string;

  constructor(private service: Service) {
    this.service.getDates().subscribe(dates => {
      this.dates = dates.map((item, index) => {
        let result = new Selection();
        result.id = index.toString();
        result.name = item;
        return result;
      });
    });

    this.service.getCurrencies().subscribe(currencies => {
      this.currencies = currencies.map((item, index) => {
        let result = new Selection();
        result.id = index.toString();
        result.name = item;
        return result;
      })
    });

    this.selectedDate = '01.04.2015';
    this.selectedCurrency = 'AUD';

    this.service.getCurrencyRate(this.selectedDate, this.selectedCurrency).subscribe(currencyRate => {
      this.printedText = currencyRate.value;
    });
  }

  onDateChange(event: any) {
    this.selectedDate = event.target.options[event.target.options.selectedIndex].text;
    this.showCurrencyRate();
  }

  onCurrencyChange(event: any) {
    this.selectedCurrency = event.target.options[event.target.options.selectedIndex].text.split(' ')[1];
    this.showCurrencyRate();
  }

  showCurrencyRate() {
    this.service.getCurrencyRate(this.selectedDate, this.selectedCurrency).subscribe(currencyRate => {
      this.printedText = currencyRate.value;
    });
  }
}
