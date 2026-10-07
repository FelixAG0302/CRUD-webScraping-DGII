export interface Company {
    id: number;
    rnc: string;
    name: string;
    commercialName: string;
    category?: string;
    paymentScheme: string;
    state: string;
    economicActivity: string;
    gubernamentalBranch: string;
}