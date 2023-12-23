using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    city = table.Column<string>(type: "text", nullable: true),
                    street = table.Column<string>(type: "text", nullable: true),
                    building = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    latitude = table.Column<double>(type: "double precision", nullable: true),
                    longitude = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_addresses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "areas",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    parent_id = table.Column<Guid>(type: "uuid", nullable: true),
                    head_hunter_id = table.Column<string>(type: "text", nullable: false),
                    head_hunter_parent_id = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_areas", x => x.id);
                    table.ForeignKey(
                        name: "fk_areas_areas_parent_id",
                        column: x => x.parent_id,
                        principalTable: "areas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "billing_types",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    head_hunter_id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_billing_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "currencies",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    head_hunter_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_currencies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    head_hunter_id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_departments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "driver_license_types",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    head_hunter_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_driver_license_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employer_types",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employer_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    head_hunter_id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "experiences",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    head_hunter_id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_experiences", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "industries",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    parent_id = table.Column<Guid>(type: "uuid", nullable: true),
                    head_hunter_id = table.Column<string>(type: "text", nullable: false),
                    head_hunter_parent_id = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_industries", x => x.id);
                    table.ForeignKey(
                        name: "fk_industries_industries_parent_id",
                        column: x => x.parent_id,
                        principalTable: "industries",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "insider_interviews",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    head_hunter_id = table.Column<long>(type: "bigint", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_insider_interviews", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "key_skills",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_key_skills", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    head_hunter_id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_languages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "phones",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    city = table.Column<string>(type: "text", nullable: true),
                    number = table.Column<string>(type: "text", nullable: true),
                    comment = table.Column<string>(type: "text", nullable: true),
                    country = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_phones", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "professional_roles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    head_hunter_id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_professional_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "schedules",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    head_hunter_id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_schedules", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "specializations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    parent_id = table.Column<Guid>(type: "uuid", nullable: true),
                    laboring = table.Column<bool>(type: "boolean", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    profarea_id = table.Column<string>(type: "text", nullable: true),
                    head_hunter_id = table.Column<string>(type: "text", nullable: false),
                    head_hunter_parent_id = table.Column<string>(type: "text", nullable: true),
                    profarea_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_specializations", x => x.id);
                    table.ForeignKey(
                        name: "fk_specializations_specializations_parent_id",
                        column: x => x.parent_id,
                        principalTable: "specializations",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "vacancy_types",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    head_hunter_id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vacancy_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "working_days",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    head_hunter_id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_working_days", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "working_time_intervals",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    head_hunter_id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_working_time_intervals", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "working_time_modes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    head_hunter_id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_working_time_modes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "metro_lines",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    area_id = table.Column<Guid>(type: "uuid", nullable: true),
                    head_hunter_id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    city_id = table.Column<string>(type: "text", nullable: true),
                    hex_color = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_metro_lines", x => x.id);
                    table.ForeignKey(
                        name: "fk_metro_lines_areas_area_id",
                        column: x => x.area_id,
                        principalTable: "areas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "employers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    area_id = table.Column<Guid>(type: "uuid", nullable: false),
                    trusted = table.Column<bool>(type: "boolean", nullable: true),
                    blacklisted = table.Column<bool>(type: "boolean", nullable: true),
                    head_hunter_id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    url = table.Column<string>(type: "text", nullable: true),
                    site_url = table.Column<string>(type: "text", nullable: true),
                    alternate_url = table.Column<string>(type: "text", nullable: true),
                    vacancies_url = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employers", x => x.id);
                    table.ForeignKey(
                        name: "fk_employers_areas_area_id",
                        column: x => x.area_id,
                        principalTable: "areas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_employers_employer_types_type_id",
                        column: x => x.type_id,
                        principalTable: "employer_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "metro_stations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    metro_line_id = table.Column<Guid>(type: "uuid", nullable: false),
                    head_hunter_id = table.Column<string>(type: "text", nullable: false),
                    order = table.Column<int>(type: "integer", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    line_id = table.Column<string>(type: "text", nullable: true),
                    line_name = table.Column<string>(type: "text", nullable: true),
                    station_id = table.Column<string>(type: "text", nullable: false),
                    station_name = table.Column<string>(type: "text", nullable: false),
                    latitude = table.Column<double>(type: "double precision", nullable: true),
                    longitude = table.Column<double>(type: "double precision", nullable: true),
                    line_id1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_metro_stations", x => x.id);
                    table.ForeignKey(
                        name: "fk_metro_stations_metro_lines_line_id1",
                        column: x => x.line_id1,
                        principalTable: "metro_lines",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "employer_branded_descriptions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    employer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employer_branded_descriptions", x => x.id);
                    table.ForeignKey(
                        name: "fk_employer_branded_descriptions_employers_employer_id",
                        column: x => x.employer_id,
                        principalTable: "employers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employer_descriptions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    employer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employer_descriptions", x => x.id);
                    table.ForeignKey(
                        name: "fk_employer_descriptions_employers_employer_id",
                        column: x => x.employer_id,
                        principalTable: "employers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employer_industries",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    employer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    industry_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employer_industries", x => x.id);
                    table.ForeignKey(
                        name: "fk_employer_industries_employers_employer_id",
                        column: x => x.employer_id,
                        principalTable: "employers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_employer_industries_industries_industry_id",
                        column: x => x.industry_id,
                        principalTable: "industries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employer_insider_interviews",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    employer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    insider_interview_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employer_insider_interviews", x => x.id);
                    table.ForeignKey(
                        name: "fk_employer_insider_interviews_employers_employer_id",
                        column: x => x.employer_id,
                        principalTable: "employers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_employer_insider_interviews_insider_interviews_insider_inte",
                        column: x => x.insider_interview_id,
                        principalTable: "insider_interviews",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employer_logos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    employer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    small = table.Column<string>(type: "text", nullable: true),
                    normal = table.Column<string>(type: "text", nullable: true),
                    original = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employer_logos", x => x.id);
                    table.ForeignKey(
                        name: "fk_employer_logos_employers_employer_id",
                        column: x => x.employer_id,
                        principalTable: "employers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vacancies",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    area_id = table.Column<Guid>(type: "uuid", nullable: false),
                    type_id = table.Column<Guid>(type: "uuid", nullable: true),
                    address_id = table.Column<Guid>(type: "uuid", nullable: true),
                    employer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    schedule_id = table.Column<Guid>(type: "uuid", nullable: false),
                    experience_id = table.Column<Guid>(type: "uuid", nullable: false),
                    employment_id = table.Column<Guid>(type: "uuid", nullable: false),
                    department_id = table.Column<Guid>(type: "uuid", nullable: true),
                    billing_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    insider_interview_id = table.Column<Guid>(type: "uuid", nullable: true),
                    has_test = table.Column<bool>(type: "boolean", nullable: false),
                    premium = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    accept_kids = table.Column<bool>(type: "boolean", nullable: false),
                    allow_messages = table.Column<bool>(type: "boolean", nullable: false),
                    accept_temporary = table.Column<bool>(type: "boolean", nullable: true),
                    accept_handicapped = table.Column<bool>(type: "boolean", nullable: false),
                    response_letter_required = table.Column<bool>(type: "boolean", nullable: false),
                    accept_incomplete_resumes = table.Column<bool>(type: "boolean", nullable: false),
                    head_hunter_id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<string>(type: "text", nullable: true),
                    alternate_url = table.Column<string>(type: "text", nullable: false),
                    apply_alternate_url = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    published_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    initial_created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vacancies", x => x.id);
                    table.ForeignKey(
                        name: "fk_vacancies_addresses_address_id",
                        column: x => x.address_id,
                        principalTable: "addresses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_vacancies_areas_area_id",
                        column: x => x.area_id,
                        principalTable: "areas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vacancies_billing_types_billing_type_id",
                        column: x => x.billing_type_id,
                        principalTable: "billing_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vacancies_departments_department_id",
                        column: x => x.department_id,
                        principalTable: "departments",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_vacancies_employers_employer_id",
                        column: x => x.employer_id,
                        principalTable: "employers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vacancies_employments_employment_id",
                        column: x => x.employment_id,
                        principalTable: "employments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vacancies_experiences_experience_id",
                        column: x => x.experience_id,
                        principalTable: "experiences",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vacancies_insider_interviews_insider_interview_id",
                        column: x => x.insider_interview_id,
                        principalTable: "insider_interviews",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_vacancies_schedules_schedule_id",
                        column: x => x.schedule_id,
                        principalTable: "schedules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vacancies_vacancy_types_type_id",
                        column: x => x.type_id,
                        principalTable: "vacancy_types",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "vacancy_branded_descriptions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    vacancy_id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vacancy_branded_descriptions", x => x.id);
                    table.ForeignKey(
                        name: "fk_vacancy_branded_descriptions_vacancies_vacancy_id",
                        column: x => x.vacancy_id,
                        principalTable: "vacancies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vacancy_contacts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    vacancy_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vacancy_contacts", x => x.id);
                    table.ForeignKey(
                        name: "fk_vacancy_contacts_vacancies_vacancy_id",
                        column: x => x.vacancy_id,
                        principalTable: "vacancies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vacancy_descriptions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    vacancy_id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vacancy_descriptions", x => x.id);
                    table.ForeignKey(
                        name: "fk_vacancy_descriptions_vacancies_vacancy_id",
                        column: x => x.vacancy_id,
                        principalTable: "vacancies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vacancy_driver_license_types",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    vacancy_id = table.Column<Guid>(type: "uuid", nullable: false),
                    driver_license_type_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vacancy_driver_license_types", x => x.id);
                    table.ForeignKey(
                        name: "fk_vacancy_driver_license_types_driver_license_types_driver_li",
                        column: x => x.driver_license_type_id,
                        principalTable: "driver_license_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vacancy_driver_license_types_vacancies_vacancy_id",
                        column: x => x.vacancy_id,
                        principalTable: "vacancies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vacancy_key_skills",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    vacancy_id = table.Column<Guid>(type: "uuid", nullable: false),
                    key_skill_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vacancy_key_skills", x => x.id);
                    table.ForeignKey(
                        name: "fk_vacancy_key_skills_key_skills_key_skill_id",
                        column: x => x.key_skill_id,
                        principalTable: "key_skills",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vacancy_key_skills_vacancies_vacancy_id",
                        column: x => x.vacancy_id,
                        principalTable: "vacancies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vacancy_languages",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    vacancy_id = table.Column<Guid>(type: "uuid", nullable: false),
                    language_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vacancy_languages", x => x.id);
                    table.ForeignKey(
                        name: "fk_vacancy_languages_languages_language_id",
                        column: x => x.language_id,
                        principalTable: "languages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vacancy_languages_vacancies_vacancy_id",
                        column: x => x.vacancy_id,
                        principalTable: "vacancies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vacancy_professional_roles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    vacancy_id = table.Column<Guid>(type: "uuid", nullable: false),
                    professional_role_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vacancy_professional_roles", x => x.id);
                    table.ForeignKey(
                        name: "fk_vacancy_professional_roles_professional_roles_professional_",
                        column: x => x.professional_role_id,
                        principalTable: "professional_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vacancy_professional_roles_vacancies_vacancy_id",
                        column: x => x.vacancy_id,
                        principalTable: "vacancies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vacancy_salaries",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    vacancy_id = table.Column<Guid>(type: "uuid", nullable: false),
                    currency_id = table.Column<Guid>(type: "uuid", nullable: false),
                    gross = table.Column<bool>(type: "boolean", nullable: true),
                    to = table.Column<decimal>(type: "numeric(18,6)", nullable: true),
                    from = table.Column<decimal>(type: "numeric(18,6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vacancy_salaries", x => x.id);
                    table.ForeignKey(
                        name: "fk_vacancy_salaries_currencies_currency_id",
                        column: x => x.currency_id,
                        principalTable: "currencies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vacancy_salaries_vacancies_vacancy_id",
                        column: x => x.vacancy_id,
                        principalTable: "vacancies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vacancy_specializations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    vacancy_id = table.Column<Guid>(type: "uuid", nullable: false),
                    specialization_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vacancy_specializations", x => x.id);
                    table.ForeignKey(
                        name: "fk_vacancy_specializations_specializations_specialization_id",
                        column: x => x.specialization_id,
                        principalTable: "specializations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vacancy_specializations_vacancies_vacancy_id",
                        column: x => x.vacancy_id,
                        principalTable: "vacancies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vacancy_working_days",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    vacancy_id = table.Column<Guid>(type: "uuid", nullable: false),
                    working_day_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vacancy_working_days", x => x.id);
                    table.ForeignKey(
                        name: "fk_vacancy_working_days_vacancies_vacancy_id",
                        column: x => x.vacancy_id,
                        principalTable: "vacancies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vacancy_working_days_working_days_working_day_id",
                        column: x => x.working_day_id,
                        principalTable: "working_days",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vacancy_working_time_intervals",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    vacancy_id = table.Column<Guid>(type: "uuid", nullable: false),
                    working_time_interval_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vacancy_working_time_intervals", x => x.id);
                    table.ForeignKey(
                        name: "fk_vacancy_working_time_intervals_vacancies_vacancy_id",
                        column: x => x.vacancy_id,
                        principalTable: "vacancies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vacancy_working_time_intervals_working_time_intervals_worki",
                        column: x => x.working_time_interval_id,
                        principalTable: "working_time_intervals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vacancy_working_time_modes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    vacancy_id = table.Column<Guid>(type: "uuid", nullable: false),
                    working_time_mode_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vacancy_working_time_modes", x => x.id);
                    table.ForeignKey(
                        name: "fk_vacancy_working_time_modes_vacancies_vacancy_id",
                        column: x => x.vacancy_id,
                        principalTable: "vacancies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vacancy_working_time_modes_working_time_modes_working_time_",
                        column: x => x.working_time_mode_id,
                        principalTable: "working_time_modes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vacancy_contact_phones",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    contact_id = table.Column<Guid>(type: "uuid", nullable: false),
                    phone_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vacancy_contact_phones", x => x.id);
                    table.ForeignKey(
                        name: "fk_vacancy_contact_phones_phones_phone_id",
                        column: x => x.phone_id,
                        principalTable: "phones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vacancy_contact_phones_vacancy_contacts_contact_id",
                        column: x => x.contact_id,
                        principalTable: "vacancy_contacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_areas_parent_id",
                table: "areas",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "ix_employer_branded_descriptions_employer_id",
                table: "employer_branded_descriptions",
                column: "employer_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_employer_descriptions_employer_id",
                table: "employer_descriptions",
                column: "employer_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_employer_industries_employer_id",
                table: "employer_industries",
                column: "employer_id");

            migrationBuilder.CreateIndex(
                name: "ix_employer_industries_industry_id",
                table: "employer_industries",
                column: "industry_id");

            migrationBuilder.CreateIndex(
                name: "ix_employer_insider_interviews_employer_id",
                table: "employer_insider_interviews",
                column: "employer_id");

            migrationBuilder.CreateIndex(
                name: "ix_employer_insider_interviews_insider_interview_id",
                table: "employer_insider_interviews",
                column: "insider_interview_id");

            migrationBuilder.CreateIndex(
                name: "ix_employer_logos_employer_id",
                table: "employer_logos",
                column: "employer_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_employers_area_id",
                table: "employers",
                column: "area_id");

            migrationBuilder.CreateIndex(
                name: "ix_employers_type_id",
                table: "employers",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "ix_industries_parent_id",
                table: "industries",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "ix_metro_lines_area_id",
                table: "metro_lines",
                column: "area_id");

            migrationBuilder.CreateIndex(
                name: "ix_metro_stations_line_id1",
                table: "metro_stations",
                column: "line_id1");

            migrationBuilder.CreateIndex(
                name: "ix_specializations_parent_id",
                table: "specializations",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "ix_vacancies_address_id",
                table: "vacancies",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "ix_vacancies_area_id",
                table: "vacancies",
                column: "area_id");

            migrationBuilder.CreateIndex(
                name: "ix_vacancies_billing_type_id",
                table: "vacancies",
                column: "billing_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_vacancies_department_id",
                table: "vacancies",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "ix_vacancies_employer_id",
                table: "vacancies",
                column: "employer_id");

            migrationBuilder.CreateIndex(
                name: "ix_vacancies_employment_id",
                table: "vacancies",
                column: "employment_id");

            migrationBuilder.CreateIndex(
                name: "ix_vacancies_experience_id",
                table: "vacancies",
                column: "experience_id");

            migrationBuilder.CreateIndex(
                name: "ix_vacancies_insider_interview_id",
                table: "vacancies",
                column: "insider_interview_id");

            migrationBuilder.CreateIndex(
                name: "ix_vacancies_schedule_id",
                table: "vacancies",
                column: "schedule_id");

            migrationBuilder.CreateIndex(
                name: "ix_vacancies_type_id",
                table: "vacancies",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "ix_vacancy_branded_descriptions_vacancy_id",
                table: "vacancy_branded_descriptions",
                column: "vacancy_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_vacancy_contact_phones_contact_id",
                table: "vacancy_contact_phones",
                column: "contact_id");

            migrationBuilder.CreateIndex(
                name: "ix_vacancy_contact_phones_phone_id",
                table: "vacancy_contact_phones",
                column: "phone_id");

            migrationBuilder.CreateIndex(
                name: "ix_vacancy_contacts_vacancy_id",
                table: "vacancy_contacts",
                column: "vacancy_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_vacancy_descriptions_vacancy_id",
                table: "vacancy_descriptions",
                column: "vacancy_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_vacancy_driver_license_types_driver_license_type_id",
                table: "vacancy_driver_license_types",
                column: "driver_license_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_vacancy_driver_license_types_vacancy_id",
                table: "vacancy_driver_license_types",
                column: "vacancy_id");

            migrationBuilder.CreateIndex(
                name: "ix_vacancy_key_skills_key_skill_id",
                table: "vacancy_key_skills",
                column: "key_skill_id");

            migrationBuilder.CreateIndex(
                name: "ix_vacancy_key_skills_vacancy_id",
                table: "vacancy_key_skills",
                column: "vacancy_id");

            migrationBuilder.CreateIndex(
                name: "ix_vacancy_languages_language_id",
                table: "vacancy_languages",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "ix_vacancy_languages_vacancy_id",
                table: "vacancy_languages",
                column: "vacancy_id");

            migrationBuilder.CreateIndex(
                name: "ix_vacancy_professional_roles_professional_role_id",
                table: "vacancy_professional_roles",
                column: "professional_role_id");

            migrationBuilder.CreateIndex(
                name: "ix_vacancy_professional_roles_vacancy_id",
                table: "vacancy_professional_roles",
                column: "vacancy_id");

            migrationBuilder.CreateIndex(
                name: "ix_vacancy_salaries_currency_id",
                table: "vacancy_salaries",
                column: "currency_id");

            migrationBuilder.CreateIndex(
                name: "ix_vacancy_salaries_vacancy_id",
                table: "vacancy_salaries",
                column: "vacancy_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_vacancy_specializations_specialization_id",
                table: "vacancy_specializations",
                column: "specialization_id");

            migrationBuilder.CreateIndex(
                name: "ix_vacancy_specializations_vacancy_id",
                table: "vacancy_specializations",
                column: "vacancy_id");

            migrationBuilder.CreateIndex(
                name: "ix_vacancy_working_days_vacancy_id",
                table: "vacancy_working_days",
                column: "vacancy_id");

            migrationBuilder.CreateIndex(
                name: "ix_vacancy_working_days_working_day_id",
                table: "vacancy_working_days",
                column: "working_day_id");

            migrationBuilder.CreateIndex(
                name: "ix_vacancy_working_time_intervals_vacancy_id",
                table: "vacancy_working_time_intervals",
                column: "vacancy_id");

            migrationBuilder.CreateIndex(
                name: "ix_vacancy_working_time_intervals_working_time_interval_id",
                table: "vacancy_working_time_intervals",
                column: "working_time_interval_id");

            migrationBuilder.CreateIndex(
                name: "ix_vacancy_working_time_modes_vacancy_id",
                table: "vacancy_working_time_modes",
                column: "vacancy_id");

            migrationBuilder.CreateIndex(
                name: "ix_vacancy_working_time_modes_working_time_mode_id",
                table: "vacancy_working_time_modes",
                column: "working_time_mode_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employer_branded_descriptions");

            migrationBuilder.DropTable(
                name: "employer_descriptions");

            migrationBuilder.DropTable(
                name: "employer_industries");

            migrationBuilder.DropTable(
                name: "employer_insider_interviews");

            migrationBuilder.DropTable(
                name: "employer_logos");

            migrationBuilder.DropTable(
                name: "metro_stations");

            migrationBuilder.DropTable(
                name: "vacancy_branded_descriptions");

            migrationBuilder.DropTable(
                name: "vacancy_contact_phones");

            migrationBuilder.DropTable(
                name: "vacancy_descriptions");

            migrationBuilder.DropTable(
                name: "vacancy_driver_license_types");

            migrationBuilder.DropTable(
                name: "vacancy_key_skills");

            migrationBuilder.DropTable(
                name: "vacancy_languages");

            migrationBuilder.DropTable(
                name: "vacancy_professional_roles");

            migrationBuilder.DropTable(
                name: "vacancy_salaries");

            migrationBuilder.DropTable(
                name: "vacancy_specializations");

            migrationBuilder.DropTable(
                name: "vacancy_working_days");

            migrationBuilder.DropTable(
                name: "vacancy_working_time_intervals");

            migrationBuilder.DropTable(
                name: "vacancy_working_time_modes");

            migrationBuilder.DropTable(
                name: "industries");

            migrationBuilder.DropTable(
                name: "metro_lines");

            migrationBuilder.DropTable(
                name: "phones");

            migrationBuilder.DropTable(
                name: "vacancy_contacts");

            migrationBuilder.DropTable(
                name: "driver_license_types");

            migrationBuilder.DropTable(
                name: "key_skills");

            migrationBuilder.DropTable(
                name: "languages");

            migrationBuilder.DropTable(
                name: "professional_roles");

            migrationBuilder.DropTable(
                name: "currencies");

            migrationBuilder.DropTable(
                name: "specializations");

            migrationBuilder.DropTable(
                name: "working_days");

            migrationBuilder.DropTable(
                name: "working_time_intervals");

            migrationBuilder.DropTable(
                name: "working_time_modes");

            migrationBuilder.DropTable(
                name: "vacancies");

            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "billing_types");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "employers");

            migrationBuilder.DropTable(
                name: "employments");

            migrationBuilder.DropTable(
                name: "experiences");

            migrationBuilder.DropTable(
                name: "insider_interviews");

            migrationBuilder.DropTable(
                name: "schedules");

            migrationBuilder.DropTable(
                name: "vacancy_types");

            migrationBuilder.DropTable(
                name: "areas");

            migrationBuilder.DropTable(
                name: "employer_types");
        }
    }
}
