
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Subject } from 'rxjs/Subject';

@Injectable()
export class AcademyProgramStateService {
    private subject = new Subject<any>();
    private academyProgramId: number;

    public setAcademyProgramId(academyProgramId: number) {
        this.academyProgramId = academyProgramId;
    }

    public getAcademyProgramId(): number {
        return this.academyProgramId;
    }

    public setAcademyProgramIdEvent(academyProgramId: number) {
        this.academyProgramId = academyProgramId;
        this.subject.next({ academyProgramId });
    }

    public clearAcademyProgramIdEvent() {
        this.subject.next();
    }

    public getAcademyProgramIdEvent(): Observable<any> {
        return this.subject.asObservable();
    }
}
