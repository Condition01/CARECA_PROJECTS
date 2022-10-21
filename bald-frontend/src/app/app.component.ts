import { Component, OnInit } from '@angular/core';

import { Careca } from './entities/Careca';
import { ToastrService } from 'ngx-toastr';
import { CarecaService } from './services/careca.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  careca?: Careca;

  constructor(
    private toastr: ToastrService,
    private carecaService: CarecaService
  ) {}

  ngOnInit(): void {}

  buscarCareca(): void {
    // const carecaMock = new Careca();
    // carecaMock.id = 1;
    // carecaMock.image =
    //   'data:image/jpeg;base64,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';
    // carecaMock.instance = 'G5DASD213FFA';
    // this.careca = carecaMock;
    // this.toastr.success('Careca gerado.', 'Sucesso!');
    this.carecaService.buscarCareca().subscribe({
      next: (careca: Careca) => {
        this.careca = careca;
        this.toastr.success('Careca gerado.', 'Sucesso!');
      },
      error: (e) => console.error(e),
    });
  }
}