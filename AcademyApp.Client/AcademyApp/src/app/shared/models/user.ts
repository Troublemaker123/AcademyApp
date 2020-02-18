export class User {
    id: number;
    userName: string;
    userRole: string;
    isActive: boolean;
    emailAdress: string;
    password: string;
    token?: string;
    isPasswordChanged:boolean;
    isEmailVerified:boolean;
}
