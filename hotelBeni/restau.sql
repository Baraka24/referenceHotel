


create table categorie(
    codecat varchar(50) primary key,
    nom varchar(50)
    )


create table produits(codeproduit varchar(50) primary key,
                      nom varchar(50),
                      quantite double,
                      prixunitaire double,
                      codecat varchar(50),
                      foreign key (codecat) references categorie(codecat)
                      )
create table vente(
    codevente varchar(50) primary key,
    datevente date,
    quantitevendue double,
    codeproduit varchar(50),
    foreign key (codeproduit) references produits(codeproduit)
    )

 create view CompteRestau as
 SELECT vente.datevente as DateVente,categorie.nom as Categories, produits.nom as Produits,produits.quantite as StockInitial,vente.quantitevendue as QuantiteVendue,produits.prixunitaire as PrixUnitaire,
(vente.quantitevendue*produits.prixunitaire) as PrixTotal,(produits.quantite-vente.quantitevendue) as StockFinal
from categorie,produits,vente where categorie.codecat=produits.codecat and vente.codeproduit= produits.codeproduit

create table chambre(numero int primary key,
                      nom varchar(50),
                      duree time,
                      prix double,
                      codecat varchar(50),
                      foreign key (codecat) references categorie(codecat)
                      )
create table reservation(
    codeReservation varchar(50) primary key,
    dateReservation date,
    numero int,
    foreign key (numero) references chambre(numero)
    )






create table entree
(
 codeEntree varchar(50) primary key,
 dateEntree datetime,
 libelle text,
 codeSource varchar(50),
 montant double,
 foreign key (codeSource) references sources(codeSource)
)


create table sortie
(
 codeSortie varchar(50) primary key,
 dateSortie datetime,
 libelle text,
 beneficiaire varchar(50),
 montant double 
)
