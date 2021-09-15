namespace Xendit.net.Enum
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum DisbursementChannelCode
    {
        Unknown,

        [EnumMember(Value = "ACEH")]
        Aceh,

        [EnumMember(Value = "ACEH_UUS")]
        AcehUus,

        [EnumMember(Value = "AGRIS")]
        Agris,

        [EnumMember(Value = "AGRONIAGA")]
        Agroniaga,

        [EnumMember(Value = "AMAR")]
        Amar,

        [EnumMember(Value = "ANDARA")]
        Andara,

        [EnumMember(Value = "ANGLOMAS")]
        Anglomas,

        [EnumMember(Value = "ANZ")]
        Anz,

        [EnumMember(Value = "ARTA_NIAGA_KENCANA")]
        ArtaNiagaKencana,

        [EnumMember(Value = "ARTHA")]
        Artha,

        [EnumMember(Value = "ARTOS")]
        Artos,

        [EnumMember(Value = "BALI")]
        Bali,

        [EnumMember(Value = "BAML")]
        Baml,

        [EnumMember(Value = "BANGKOK")]
        Bangkok,

        [EnumMember(Value = "BANTEN")]
        Banten,

        [EnumMember(Value = "BCA")]
        Bca,

        [EnumMember(Value = "BCA_SYR")]
        BcaSyr,

        [EnumMember(Value = "BENGKULU")]
        Bengkulu,

        [EnumMember(Value = "BISNIS_INTERNASIONAL")]
        BisnisInternasional,

        [EnumMember(Value = "BJB")]
        Bjb,

        [EnumMember(Value = "BJB_SYR")]
        BjbSyr,

        [EnumMember(Value = "BNI")]
        Bni,

        [EnumMember(Value = "BNI_SYR")]
        BniSyr,

        [EnumMember(Value = "BNP_PARIBAS")]
        BnpParibas,

        [EnumMember(Value = "BOC")]
        Boc,

        [EnumMember(Value = "BRI")]
        Bri,

        [EnumMember(Value = "BRI_SYR")]
        BriSyr,

        [EnumMember(Value = "BTN")]
        Btn,

        [EnumMember(Value = "BTN_UUS")]
        BtnUus,

        [EnumMember(Value = "BTPN_SYARIAH")]
        BtpnSyariah,

        [EnumMember(Value = "BUKOPIN")]
        Bukopin,

        [EnumMember(Value = "BUKOPIN_SYR")]
        BukopinSyr,

        [EnumMember(Value = "BUMI_ARTA")]
        BumiArta,

        [EnumMember(Value = "BSI")]
        Bsi,

        [EnumMember(Value = "CAPITAL")]
        Capital,

        [EnumMember(Value = "CCB")]
        Ccb,

        [EnumMember(Value = "CENTRATAMA")]
        Centratama,

        [EnumMember(Value = "CHINATRUST")]
        Chinatrust,

        [EnumMember(Value = "CIMB")]
        Cimb,

        [EnumMember(Value = "CIMB_UUS")]
        CimbUus,

        [EnumMember(Value = "CITIBANK")]
        Citibank,

        [EnumMember(Value = "COMMONWEALTH")]
        Commonwealth,

        [EnumMember(Value = "DAERAH_ISTIMEWA")]
        DaerahIstimewa,

        [EnumMember(Value = "DAERAH_ISTIMEWA_UUS")]
        DaerahIstimewaUus,

        [EnumMember(Value = "DANAMON")]
        Danamon,

        [EnumMember(Value = "DANAMON_UUS")]
        DanamonUus,

        [EnumMember(Value = "DBS")]
        Dbs,

        [EnumMember(Value = "DEUTSCHE")]
        Deutsche,

        [EnumMember(Value = "DINAR_INDONESIA")]
        DinarIndonesia,

        [EnumMember(Value = "DKI")]
        Dki,

        [EnumMember(Value = "DKI_UUS")]
        DkiUus,

        [EnumMember(Value = "EXIMBANK")]
        Eximbank,

        [EnumMember(Value = "FAMA")]
        Fama,

        [EnumMember(Value = "GANESHA")]
        Ganesha,

        [EnumMember(Value = "HANA")]
        Hana,

        [EnumMember(Value = "HARDA_INTERNASIONAL")]
        HardaInternasional,

        [EnumMember(Value = "HIMPUNAN_SAUDARA")]
        HimpunanSaudara,

        [EnumMember(Value = "HSBC")]
        Hsbc,

        [EnumMember(Value = "HSBC_UUS")]
        HsbcUus,

        [EnumMember(Value = "ICBC")]
        Icbc,

        [EnumMember(Value = "INA_PERDANA")]
        InaPerdana,

        [EnumMember(Value = "INDEX_SELINDO")]
        IndexSelindo,

        [EnumMember(Value = "INDIA")]
        India,

        [EnumMember(Value = "JAMBI")]
        Jambi,

        [EnumMember(Value = "JAMBI_UUS")]
        JambiUus,

        [EnumMember(Value = "JASA_JAKARTA")]
        JasaJakarta,

        [EnumMember(Value = "JAWA_TENGAH")]
        JawaTengah,

        [EnumMember(Value = "JAWA_TENGAH_UUS")]
        JawaTengahUus,

        [EnumMember(Value = "JAWA_TIMUR")]
        JawaTimur,

        [EnumMember(Value = "JAWA_TIMUR_UUS")]
        JawaTimurUus,

        [EnumMember(Value = "JPMORGAN")]
        Jpmorgan,

        [EnumMember(Value = "JTRUST")]
        Jtrust,

        [EnumMember(Value = "KALIMANTAN_BARAT")]
        KalimantanBarat,

        [EnumMember(Value = "KALIMANTAN_BARAT_UUS")]
        KalimantanBaratUus,

        [EnumMember(Value = "KALIMANTAN_SELATAN")]
        KalimantanSelatan,

        [EnumMember(Value = "KALIMANTAN_SELATAN_UUS")]
        KalimantanSelatanUus,

        [EnumMember(Value = "KALIMANTAN_TENGAH")]
        KalimantanTengah,

        [EnumMember(Value = "KALIMANTAN_TIMUR")]
        KalimantanTimur,

        [EnumMember(Value = "KALIMANTAN_TIMUR_UUS")]
        KalimantanTimurUus,

        [EnumMember(Value = "KESEJAHTERAAN_EKONOMI")]
        KesejahteraanEkonomi,

        [EnumMember(Value = "LAMPUNG")]
        Lampung,

        [EnumMember(Value = "MALUKU")]
        Maluku,

        [EnumMember(Value = "MANDIRI")]
        Mandiri,

        [EnumMember(Value = "MANDIRI_SYR")]
        MandiriSyr,

        [EnumMember(Value = "MANDIRI_TASPEN")]
        MandiriTaspen,

        [EnumMember(Value = "MASPION")]
        Maspion,

        [EnumMember(Value = "MAYAPADA")]
        Mayapada,

        [EnumMember(Value = "MAYBANK")]
        Maybank,

        [EnumMember(Value = "MAYBANK_SYR")]
        MaybankSyr,

        [EnumMember(Value = "MAYORA")]
        Mayora,

        [EnumMember(Value = "MEGA")]
        Mega,

        [EnumMember(Value = "MEGA_SYR")]
        MegaSyr,

        [EnumMember(Value = "MESTIKA_DHARMA")]
        MestikaDharma,

        [EnumMember(Value = "MITRA_NIAGA")]
        MitraNiaga,

        [EnumMember(Value = "MITSUI")]
        Mitsui,

        [EnumMember(Value = "MIZUHO")]
        Mizuho,

        [EnumMember(Value = "MNC_INTERNASIONAL")]
        MncInternasional,

        [EnumMember(Value = "MUAMALAT")]
        Muamalat,

        [EnumMember(Value = "MULTI_ARTA_SENTOSA")]
        MultiArtaSentosa,

        [EnumMember(Value = "NATIONALNOBU")]
        Nationalnobu,

        [EnumMember(Value = "NUSA_TENGGARA_BARAT")]
        NusaTenggaraBarat,

        [EnumMember(Value = "NUSA_TENGGARA_BARAT_UUS")]
        NusaTenggaraBaratUus,

        [EnumMember(Value = "NUSA_TENGGARA_TIMUR")]
        NusaTenggaraTimur,

        [EnumMember(Value = "NUSANTARA_PARAHYANGAN")]
        NusantaraParahyangan,

        [EnumMember(Value = "OCBC")]
        Ocbc,

        [EnumMember(Value = "OCBC_UUS")]
        OcbcUus,

        [EnumMember(Value = "OKE")]
        Oke,

        [EnumMember(Value = "PANIN")]
        Panin,

        [EnumMember(Value = "PANIN_SYR")]
        PaninSyr,

        [EnumMember(Value = "PAPUA")]
        Papua,

        [EnumMember(Value = "PERMATA")]
        Permata,

        [EnumMember(Value = "PERMATA_UUS")]
        PermataUus,

        [EnumMember(Value = "PRIMA_MASTER")]
        PrimaMaster,

        [EnumMember(Value = "QNB_INDONESIA")]
        QnbIndonesia,

        [EnumMember(Value = "RABOBANK")]
        Rabobank,

        [EnumMember(Value = "RBS")]
        Rbs,

        [EnumMember(Value = "RESONA")]
        Resona,

        [EnumMember(Value = "RIAU_DAN_KEPRI")]
        RiauDanKepri,

        [EnumMember(Value = "RIAU_DAN_KEPRI_UUS")]
        RiauDanKepriUus,

        [EnumMember(Value = "ROYAL")]
        Royal,

        [EnumMember(Value = "SAHABAT_SAMPOERNA")]
        SahabatSampoerna,

        [EnumMember(Value = "SBI_INDONESIA")]
        SbiIndonesia,

        [EnumMember(Value = "SHINHAN")]
        Shinhan,

        [EnumMember(Value = "SINARMAS")]
        Sinarmas,

        [EnumMember(Value = "SINARMAS_UUS")]
        SinarmasUus,

        [EnumMember(Value = "STANDARD_CHARTERED")]
        StandardChartered,

        [EnumMember(Value = "SULAWESI")]
        Sulawesi,

        [EnumMember(Value = "SULAWESI_TENGGARA")]
        SulawesiTenggara,

        [EnumMember(Value = "SULSELBAR")]
        Sulselbar,

        [EnumMember(Value = "SULSELBAR_UUS")]
        SulselbarUus,

        [EnumMember(Value = "SULUT")]
        Sulut,

        [EnumMember(Value = "SUMATERA_BARAT")]
        SumateraBarat,

        [EnumMember(Value = "SUMATERA_BARAT_UUS")]
        SumateraBaratUus,

        [EnumMember(Value = "SUMSEL_DAN_BABEL")]
        SumselDanBabel,

        [EnumMember(Value = "SUMSEL_DAN_BABEL_UUS")]
        SumselDanBabelUus,

        [EnumMember(Value = "SUMUT")]
        Sumut,

        [EnumMember(Value = "SUMUT_UUS")]
        SumutUus,

        [EnumMember(Value = "TABUNGAN_PENSIUNAN_NASIONAL")]
        TabunganPensiunanNasional,

        [EnumMember(Value = "TOKYO")]
        Tokyo,

        [EnumMember(Value = "UOB")]
        Uob,

        [EnumMember(Value = "VICTORIA_INTERNASIONAL")]
        VictoriaInternasional,

        [EnumMember(Value = "VICTORIA_SYR")]
        VictoriaSyr,

        [EnumMember(Value = "WOORI")]
        Woori,

        [EnumMember(Value = "WOORI_SAUDARA")]
        WooriSaudara,

        [EnumMember(Value = "YUDHA_BHAKTI")]
        YudhaBhakti,

        [EnumMember(Value = "GOPAY")]
        Gopay,

        [EnumMember(Value = "OVO")]
        Ovo,

        [EnumMember(Value = "DANA")]
        Dana,

        [EnumMember(Value = "LINKAJA")]
        Linkaja,

        [EnumMember(Value = "SHOPEEPAY")]
        Shopeepay,

        [EnumMember(Value = "PH_ABP")]
        PhAbp,

        [EnumMember(Value = "PH_AUB")]
        PhAub,

        [EnumMember(Value = "PH_BDO")]
        PhBdo,

        [EnumMember(Value = "PH_BMB")]
        PhBmb,

        [EnumMember(Value = "PH_BOC")]
        PhBoc,

        [EnumMember(Value = "PH_BPI")]
        PhBpi,

        [EnumMember(Value = "PH_BPIDB")]
        PhBpidb,

        [EnumMember(Value = "PH_BRB")]
        PhBrb,

        [EnumMember(Value = "PH_CBC")]
        PhCbc,

        [EnumMember(Value = "PH_CBS")]
        PhCbs,

        [EnumMember(Value = "PH_CEBRUR")]
        PhCebrur,

        [EnumMember(Value = "PH_CMG")]
        PhCmg,

        [EnumMember(Value = "PH_CRD")]
        PhCrd,

        [EnumMember(Value = "PH_CTBC")]
        PhCtbc,

        [EnumMember(Value = "PH_DBI")]
        PhDbi,

        [EnumMember(Value = "PH_DBP")]
        PhDbp,

        [EnumMember(Value = "PH_DCP")]
        PhDcp,

        [EnumMember(Value = "PH_EQB")]
        PhEqb,

        [EnumMember(Value = "PH_EWB")]
        PhEwb,

        [EnumMember(Value = "PH_EWR")]
        PhEwr,

        [EnumMember(Value = "PH_ING")]
        PhIng,

        [EnumMember(Value = "PH_ISLA")]
        PhIsla,

        [EnumMember(Value = "PH_LBP")]
        PhLbp,

        [EnumMember(Value = "PH_MET")]
        PhMet,

        [EnumMember(Value = "PH_MPI")]
        PhMpi,

        [EnumMember(Value = "PH_MSB")]
        PhMsb,

        [EnumMember(Value = "PH_OMNI")]
        PhOmni,

        [EnumMember(Value = "PH_ONB")]
        PhOnb,

        [EnumMember(Value = "PH_PAR")]
        PhPar,

        [EnumMember(Value = "PH_PBB")]
        PhPbb,

        [EnumMember(Value = "PH_PBC")]
        PhPbc,

        [EnumMember(Value = "PH_PNB")]
        PhPnb,

        [EnumMember(Value = "PH_PNBSB")]
        PhPnbsb,

        [EnumMember(Value = "PH_PRB")]
        PhPrb,

        [EnumMember(Value = "PH_PSB")]
        PhPsb,

        [EnumMember(Value = "PH_PTC")]
        PhPtc,

        [EnumMember(Value = "PH_PVB")]
        PhPvb,

        [EnumMember(Value = "PH_QCB")]
        PhQcb,

        [EnumMember(Value = "PH_QCRB")]
        PhQcrb,

        [EnumMember(Value = "PH_RBG")]
        PhRbg,

        [EnumMember(Value = "PH_RCBC")]
        PhRcbc,

        [EnumMember(Value = "PH_ROB")]
        PhRob,

        [EnumMember(Value = "PH_SBA")]
        PhSba,

        [EnumMember(Value = "PH_SEC")]
        PhSec,

        [EnumMember(Value = "PH_SSB")]
        PhSsb,

        [EnumMember(Value = "PH_UCBSB")]
        PhUcbsb,

        [EnumMember(Value = "PH_UCPB")]
        PhUcpb,

        [EnumMember(Value = "PH_UBP")]
        PhUbp,

        [EnumMember(Value = "PH_WDB")]
        PhWdb,

        [EnumMember(Value = "PH_YUANSB")]
        PhYuansb,

        [EnumMember(Value = "PH_COINS")]
        PhCoins,

        [EnumMember(Value = "PH_GCASH")]
        PhGcash,

        [EnumMember(Value = "PH_GRABPAY")]
        PhGrabpay,

        [EnumMember(Value = "PH_PAYMAYA")]
        PhPaymaya,

        [EnumMember(Value = "PH_SPY")]
        PhSpy,
    }
}
