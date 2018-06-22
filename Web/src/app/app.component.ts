import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LogModel } from './../Model/LogModel';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
    lstLog: any = [];
    public model: any = { id: '' };

    constructor(public http: HttpClient) { }

    getAll()
    {
        if (this.model.id === '') {

            this.getLog().then((data) => {
                this.lstLog = [];
                this.lstLog = <LogModel>data;
            });
        }
        else
        {
            let params = '?id=' + this.model.id;

            this.getLogId(params).then((data) => {
                this.lstLog = [];
                this.lstLog.push(<LogModel>data);
            });
        }
    }

    getLog(): Promise<LogModel[] | void>
    {
        return new Promise<LogModel[]>((resolve, reject) => {
            this.http.get<LogModel[]>('http://localhost:61932/api/log/get').subscribe(
                (data) => resolve(data),
                (error) => reject(error)
            );
        });
    }

    getLogId(params: any): Promise<LogModel | void>
    {
        return new Promise<LogModel>((resolve, reject) => {
            this.http.get<LogModel>('http://localhost:61932/api/log/GetId' + params).subscribe(
                (data) => resolve(data),
                (error) => reject(error)
            );
        });
    }
}
