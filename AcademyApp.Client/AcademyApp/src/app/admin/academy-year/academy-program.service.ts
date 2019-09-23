
import { Injectable } from '@angular/core';
import { AcademyProgram } from 'src/app/shared/models/academyProgram';

@Injectable()
export class AcademyProgramService {
    private academyProgram: AcademyProgram;

    public setAcademyProgram(academyProgram: AcademyProgram) {
        this.academyProgram = academyProgram;
    }

    public getAcademyProgram() : AcademyProgram {
        return this.academyProgram;
    }
}